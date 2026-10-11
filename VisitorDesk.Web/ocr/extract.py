"""Local OCR only. Never sends identity documents to an external service."""
import json
import os
import re
import sys
from PIL import Image, ImageOps, ImageFilter
import pytesseract

if os.environ.get("TESSERACT_CMD"):
    pytesseract.pytesseract.tesseract_cmd = os.environ["TESSERACT_CMD"]
elif os.path.exists(r"C:\Program Files\Tesseract-OCR\tesseract.exe"):
    pytesseract.pytesseract.tesseract_cmd = r"C:\Program Files\Tesseract-OCR\tesseract.exe"
Image.MAX_IMAGE_PIXELS = 25000000
with Image.open(sys.argv[1]) as image:
    image = ImageOps.exif_transpose(image)
    image.thumbnail((2400, 2400))
    image = ImageOps.autocontrast(ImageOps.grayscale(image)).filter(ImageFilter.SHARPEN)
    text = pytesseract.image_to_string(image, config="--psm 6", timeout=30)
fields = {}
for key, pattern in {
    "name": r"(?:full\s*name|name)\s*[:\-]\s*([^\n]+)",
    "idNumber": r"(?:id\s*(?:no\.?|number)?|personal\s*(?:no\.?|number))\s*[:\-]\s*([\w-]+)",
    "nationality": r"nationality\s*[:\-]\s*([^\n]+)",
}.items():
    match = re.search(pattern, text, re.IGNORECASE)
    if match:
        fields[key] = match.group(1).strip()
print(json.dumps({"text": text, "fields": fields, "message": "Review every extracted field against the original document."}))
