# Body mass index Berechnung
def ErmittleText(bmi : float):  # man kann mit "-> str" einen rückgabe-datentyp bestimmen, braucht man aber fast nie
    text = ""
    if bmi < 18.5:
        text = f"LAUCH: {bmi:2f}"
    elif 18.5 <= bmi <= 25:
        text = f"NORMAL: {bmi:2f}"
        if bmi > 24:
            text = text + f"Achtung! Du bist fast FETT."
    else:
        text = f"FETT: {bmi:2f}"

    return text

gewicht = int(input("Gib ein Gewicht in kg ein: "))
groesse = int(input("Gib eine Größe in cm ein: "))/100.0

bmi = gewicht / (groesse**2)

beschreibung = ErmittleText(bmi)
print(f"{beschreibung}")








