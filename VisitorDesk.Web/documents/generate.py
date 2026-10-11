"""Overlay the original forms using coordinates from GenerateDocument.Library.

Input is JSON on stdin. Templates are read only; output is a separate PDF.
Coordinates use PDF points measured from the bottom left.
"""
import base64
import io
import json
import sys
from datetime import datetime
from pathlib import Path
from zoneinfo import ZoneInfo

from pypdf import PdfReader, PdfWriter
from reportlab.pdfgen import canvas
from reportlab.lib.utils import ImageReader
from PIL import Image
Image.MAX_IMAGE_PIXELS = 25000000


def generate(data, template_directory, output):
    def value(key):
        text = data.get(key, "").strip()
        if key in ("dob", "expiry", "visitDate", "passportIssued", "passportExpiry") and text:
            return datetime.strptime(text, "%Y-%m-%d").strftime("%d-%m-%Y")
        return text

    def text(c, key, x, y, width=130, size=8):
        content = value(key)
        if not content:
            return
        # Avoid silent replacement of unsupported identity characters.
        try:
            content.encode("cp1252")
        except UnicodeEncodeError:
            raise ValueError("Use the English identity fields for this template: " + key)
        while c.stringWidth(content, "Helvetica", size) > width and size > 5:
            size -= .25
        if c.stringWidth(content, "Helvetica", size) > width:
            raise ValueError("Field is too long for template: " + key)
        c.setFont("Helvetica", size)
        c.drawString(x, y, content)

    def portrait(c, x, y, width, height):
        source = data.get("photo", "")
        if source:
            prefix, encoded = source.split(",", 1)
            if prefix not in ("data:image/png;base64", "data:image/jpeg;base64"):
                raise ValueError("Unsupported portrait")
            c.drawImage(ImageReader(io.BytesIO(base64.b64decode(encoded, validate=True))), x, y,
                        width, height, preserveAspectRatio=True, anchor="c", mask="auto")

    kind = value("template")
    data = dict(data)
    data["today"] = datetime.now(ZoneInfo("Asia/Qatar")).strftime("%d-%m-%Y")
    if kind == "card":
        if value("cardType") not in ("VISITOR", "CONTRACTOR") or not value("cardNumber") or not value("photo"):
            raise ValueError("Card type, card number and portrait are required")
        c = canvas.Canvas(str(output), pagesize=(252.72, 153.09))
        portrait(c, 10, 40, 100, 80)
        text(c, "cardNumber", 130, 100, 112, 16)
        text(c, "cardType", 120, 60, 123, 16)
        text(c, "name", 10, 25, 232, 10)
        c.setFillColorRGB(*((.5, .5, .5) if value("cardType") == "VISITOR" else (.663, .408, .192)))
        c.rect(0, 0, 252.72, 20, fill=1, stroke=0)
        c.save()
        return
    if kind not in ("visitor", "contractor"):
        raise ValueError("Unknown template")
    reader = PdfReader(Path(template_directory) / ("Visitor.pdf" if kind == "visitor" else "Contractor.pdf"))
    if len(reader.pages) < 3:
        raise ValueError("Expected at least three template pages")
    writer = PdfWriter()
    writer.clone_document_from_reader(reader)
    mappings = {}
    if kind == "visitor":
        mappings[1] = [("name",182,645,270),("today",470,645,95),("idNumber",470,597,95),
            ("dob",470,550,95),("expiry",470,500,95),("nationality",470,453,95),
            ("company",182,597,205),("purpose",182,550,205),("host",182,503,205),
            ("area",182,455,205),("duration",470,410,95),("visitDate",182,410,205),
            ("departmentManager",182,370,205),("productionManager",182,326,205),("securityController",182,280,205)]
        mappings[2] = [("name",105,638,440),("title",100,603,200),("company",355,603,200),("today",400,430,130)]
    else:
        parts = value("name").split()
        data.update(firstName=parts[0], middleName=parts[1] if len(parts)>2 else "", lastName=" ".join(parts[2:] if len(parts)>2 else parts[1:]))
        mappings[1] = [("name",110,710,440),("title",100,680,200),("company",350,680,205),("today",400,505,130)]
        mappings[2] = [("firstName",390,580,155),("middleName",228,580,150),("lastName",65,580,150),
            ("address",340,550,205),("city",235,550,95),("state",130,550,95),("zip",65,543,60),
            ("email",318,515,225),("phone",197,515,115),("homePhone",65,515,120),
            ("securityNo",310,483,230),("company",307,450,235),
            ("dob",110,450,140),("nationality",90,353,120),("purpose",400,353,145),
            ("duration",365,317,180),("emergencyPhone",150,317,160),("alias",65,262,480),
            ("residence",65,192,480),("today",425,73,120),
            ("passportPlace",310,385,58),("passportIssued",370,385,175)]
        if value("identityType") == "passport":
            mappings[2] += [("idNumber",150,417,150),("expiry",150,385,150)]
        else:
            mappings[2] += [("idNumber",310,417,230),
                            ("passportNumber",150,417,150),("passportExpiry",150,385,150)]
    for index, fields in mappings.items():
        page = writer.pages[index]
        buffer = io.BytesIO()
        c = canvas.Canvas(buffer, pagesize=(float(page.mediabox.width), float(page.mediabox.height)))
        for field in fields:
            text(c, *field)
        if kind == "contractor" and index == 2:
            if value("felony") not in ("", "Yes", "No"):
                raise ValueError("Choose Yes or No for the conviction question")
            if value("felony"):
                c.setFillColorRGB(0, 0, 0)
                c.circle(125.8 if value("felony") == "Yes" else 83.2, 482.8, 2.5, fill=1, stroke=0)
        if kind == "visitor" and index == 1:
            c.setFont("Helvetica", 7)
            for label, y in [("Date of birth", 550), ("ID expiry", 500), ("Nationality", 453)]:
                c.drawString(392, y, label)
        if index == 2:
            portrait(c, 455, 660, 70, 70) if kind == "visitor" else portrait(c, 440, 632, 100, 100)
        c.save()
        page.merge_page(PdfReader(buffer).pages[0])
    with open(output, "wb") as stream:
        writer.write(stream)


if __name__ == "__main__":
    try:
        generate(json.load(sys.stdin), sys.argv[1], sys.argv[2])
    except (ValueError, IndexError, UnicodeError) as error:
        print(json.dumps({"error": str(error)}))
        sys.exit(2)
