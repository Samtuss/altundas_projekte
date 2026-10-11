import math

def berechne_celsius(kelvin):
    return kelvin - 273.15

process = True

while process:
    userinput = input("Was möchtest du berechnen? \nKelvin oder Celsius? (x für Ende)")

    if userinput == "Kelvin":
        celsius = float(input("Celsius: "))
        kelvin = celsius + 273.15
        print(f"Ausgabe: {kelvin:.2f}K ")
    elif userinput == "Celsius":
        kelvin = float(input("Kelvin: "))
        celsius = berechne_celsius(kelvin)
        print(f"Ausgabe: {round(celsius, 2)} C")
    elif userinput.lower() == "x":
        process = False
    else:
        print("Falsche Eingabe!")
