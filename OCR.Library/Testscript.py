
import sys

# Accessing command-line arguments passed from C#
argument1 = sys.argv[1]
argument2 = int(sys.argv[2])
argument3 = float(sys.argv[3])

# Process the arguments

from PIL import Image
import pytesseract
from matplotlib import pyplot as plt

print("Running... ")

img = cv2.imread("D:\\Images\\image00116.jpg")
#img = cv2.imread(imagePath)
gray = cv2.cvtColor(img, cv2.COLOR_BGR2GRAY)
gray[gray>75] = 255
gray[gray<=75] = 0
#save("D:\\Images\\image00103_Processed.jpg")
print("Processed... ")
cv2.imwrite("D:\\ProcessedImage\\image00102_Processed.jpg", gray)
#plt.imshow(gray, cmap="gray")
#plt.show()

print("Argument 1:", argument1)
print("Argument 2:", argument2)
print("Argument 3:", argument3)

#pytesseract.pytesseract.tesseract_cmd = r"C:\\Program Files\\Tesseract-OCR\\tesseract.exe"
#print(pytesseract.image_to_string(Image.open("D:\\Images\\image00108_Processed.jpg")))
#print(pytesseract.image_to_string(Image.open("D:\\Images\\image00102_Processed.jpg")))