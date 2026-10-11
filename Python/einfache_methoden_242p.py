import math

def kreisflaeche_berechnen(radius):
    return math.pi * radius**2

def kreisflaeche_umfang_berechnen(radius):
    flaeche = math.pi * radius**2
    umfang = 2*math.pi*radius
    return (flaeche, umfang)

def kugel_volumen_flaeche(radius):
    volumen = (4 * math.pi * radius**3) / 3
    flaeche = 4 * math.pi * radius**2
    return (volumen, flaeche)

def kugel_radius(volumen):
    return ((3*volumen)/(4*math.pi))**(1/3)

def kawasdasseinsoll(a, b, c):
    return a + 1 / (b + (1/(c+1)))


def binaer_zu_dezimal(binaer_string: str) -> int:
    return int(binaer_string, 2)


labba1 = kreisflaeche_berechnen(5)
print(f"Fläche: {labba1:.2f}")
labba2 = kreisflaeche_umfang_berechnen(5)
print(f"Fläche: {labba2[0]:.2f}, Umfang: {labba2[1]:.2f}")
labba3 = kugel_volumen_flaeche(5)
print(f"Volumen: {labba3[0]:.2f}, Fläche: {labba3[1]:.2f}")
labba4 = kugel_radius(100)
print(f"Kugelradius: {labba4:.2f}")
labba5 = kawasdasseinsoll(29, 2, 2)
print(f"{labba5:.2f}")
labba6 = binaer_zu_dezimal("1101")
print(f"{labba6}")