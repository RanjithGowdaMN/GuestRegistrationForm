import sys
from PIL import Image
import pytesseract
from matplotlib import pyplot as plt

import cv2
arguments = sys.argv[1:]
for arg in arguments:
    print("Argument:", arg)
    imagePath = arg

def main():
    print("Hello World!")

if __name__ == "__main__":
    main()


img = cv2.imread("D:\\Images\\image00116.jpg")
#img = cv2.imread(imagePath)
gray = cv2.cvtColor(img, cv2.COLOR_BGR2GRAY)
gray[gray>75] = 255
gray[gray<=75] = 0
#save("D:\\Images\\image00103_Processed.jpg")

cv2.imwrite("D:\\ProcessedImage\\image00102_Processed.jpg", gray)
#plt.imshow(gray, cmap="gray")
#plt.show()


#pytesseract.pytesseract.tesseract_cmd = r"C:\\Program Files\\Tesseract-OCR\\tesseract.exe"
#print(pytesseract.image_to_string(Image.open("D:\\Images\\image00108_Processed.jpg")))
#print(pytesseract.image_to_string(Image.open("D:\\Images\\image00102_Processed.jpg")))