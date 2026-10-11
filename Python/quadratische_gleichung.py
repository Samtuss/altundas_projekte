import math

# Python verwendet snakecase
def solve_quadratic_equation(a, b, c):
    discriminant = b**2 - 4*a*c
    if discriminant < 0:
        return "ayri", "keine lösung"
        # mi bombo! Python kann bei einer Methode verschiedene Datentypen zurückgeben.
    root = math.sqrt(discriminant)
    x1 = (-b + root) / (2*a)
    x2 = (-b - root) / (2*a)
    return x1, x2 # tuple - geht auch so: [x1, x2]

a = float(input("Gib a ein: "))
b = float(input("Gib b ein: "))
c = float(input("Gib c ein: "))

value1, value2 = solve_quadratic_equation(a, b, c)
print(f"{value1}, {value2}")