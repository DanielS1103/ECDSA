using ECDsa;

Tools.ECPoint p1 = new () { x = 3.096, y = 6.055 };
Tools.ECPoint p1 = new () { x = -1.650, y = 1.581 };
Tools.ECPoint p3 = Tools.Add(p1, p2);

console.WriteLine($"({p3.x}, {p3.y})");