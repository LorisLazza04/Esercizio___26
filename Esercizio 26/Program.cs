Raccolta r = new Raccolta();

r.Add(new Triangolo("Scaleno", 4, 4, 5, 6));
r.Add(new Triangolo("Isoscele", 4, 5, 6));
r.Add(new Triangolo("Equilatero", 6, 7));
r.Add(new Rettangolo(4, 5));
r.Add(new Rettangolo(2, 5));
r.Add(new Quadrato(5));
r.Add(new Quadrato(2));
r.Add(new Rombo(6, 5, 4));
Console.WriteLine("Indice: " + r.Add(new Circonferenza(3)));

Console.WriteLine(r.stampa());

Console.WriteLine("------MaxArea-------");
Console.WriteLine(r.maxArea().ToString());
Console.WriteLine();
Console.WriteLine("------MinPerimetro-------");
Console.WriteLine(r.minPerimetro().ToString());
Console.WriteLine("---------------------");
Console.WriteLine();

r.ordina();

Console.WriteLine(r.stampa());

r.rimuoviUltima();

Console.WriteLine(r.stampa());

r.rimuoviIndice(6);
Console.WriteLine(r.stampa());

Console.WriteLine(r.ricerca());
Console.WriteLine(r.creaLista().ToString());
abstract class FiguraGeometrica : IComparable, ICloneable
{
    protected double baseFigura;
    public double BaseFigura { get => baseFigura; set => baseFigura = value; }
    protected double altezza;
    public double Altezza { get => altezza; set => altezza = value; }
    protected double lato;
    public double Lato { get => lato; set => lato = value; }
    protected double raggio;
    public double Raggio { get => raggio; set => raggio = value; }
    protected double perimetro;
    public double Perimetro { get; }
    protected double area;
    public double Area { get; }
    public abstract double CalcolaPerimetro();
    public abstract double CalcolaArea();
    public override abstract bool Equals(object obj);
    public abstract FiguraGeometrica Clone();
    object ICloneable.Clone()
    {
        return (object)Clone();
    }
    public abstract string ToString();
    public int CompareTo(object obj)
    {
        FiguraGeometrica figura = (FiguraGeometrica)obj;
        if (this.area == figura.area)
        {
            return 0;
        }
        else
        {
            if (this.area > figura.area)
            {
                return 1;
            }
            return -1;
        }
    }
    public int CompareToPerimetro(object obj)
    {
        FiguraGeometrica figura = (FiguraGeometrica)obj;
        if (this.perimetro == figura.perimetro)
        {
            return 0;
        }
        else
        {
            if (this.perimetro > figura.perimetro)
            {
                return 1;
            }
            return -1;
        }
    }

}
class Triangolo : FiguraGeometrica, IComparable
{
    string tipo;
    double b;
    double c;
    public Triangolo(string tipo, double baseFigura, double altezza, double b, double c)
    {
        this.b = b;
        this.c = c;
        this.tipo = tipo;
        this.baseFigura = baseFigura;
        this.altezza = altezza;
    }
    public Triangolo(string tipo, double baseFigura, double altezza, double b)
    {
        this.b = b;
        this.tipo = tipo;
        this.baseFigura = baseFigura;
        this.altezza = altezza;
    }
    public Triangolo(string tipo, double baseFigura, double altezza)
    {
        this.tipo = tipo;
        this.baseFigura = baseFigura;
        this.altezza = altezza;
    }
    public override double CalcolaPerimetro()
    {
        switch (tipo)
        {
            case "Scaleno":
                perimetro = baseFigura + b + c;
                break;
            case "Isoscele":
                c = b;
                perimetro = baseFigura + b * 2;
                break;
            case "Equilatero":
                c = baseFigura;
                b = baseFigura;
                perimetro = baseFigura * 3;
                break;
        }
        return perimetro;
    }
    public override double CalcolaArea()
    {
        area = (baseFigura * altezza) / 2;
        return area;
    }
    public override bool Equals(object obj)
    {
        Triangolo figura2 = (Triangolo)obj;
        if (figura2.area == this.area)
        {
            return true;
        }
        return false;
    }
    public override FiguraGeometrica Clone()
    {
        switch (tipo)
        {
            case "Scaleno":
                return new Triangolo(tipo, baseFigura, altezza, b, c);
            case "Isoscele":
                c = b;
                return new Triangolo(tipo, baseFigura, altezza, b);
            default:
                return new Triangolo(tipo, baseFigura, altezza);
        }
    }
    public override string ToString()
    {
        switch (tipo)
        {
            case "Scaleno":
                return "Figura: Triangolo \n Lati: " + baseFigura + "," + b + "," + c + "\n Perimetro: " + perimetro + "\n Area: " + area;
            case "Isoscele":
                c = b;
                return "Figura: Triangolo \n Lati: " + baseFigura + "," + b + "\n Perimetro: " + perimetro + "\n Area: " + area;
            default:
                return "Figura: Triangolo \n Lati: " + baseFigura + "\n Perimetro: " + perimetro + "\n Area: " + area;
        }
    }
}
class Rettangolo : FiguraGeometrica
{
    public Rettangolo(double lato)
    {
        this.lato = lato;
    }
    public Rettangolo(double baseFigura, double altezza)
    {
        this.baseFigura = baseFigura;
        this.altezza = altezza;
    }
    public override double CalcolaPerimetro()
    {
        perimetro = (baseFigura + altezza) * 2;
        return perimetro;
    }
    public override double CalcolaArea()
    {
        area = baseFigura * altezza;
        return area;
    }
    public override bool Equals(object obj)
    {
        Rettangolo figura2 = (Rettangolo)obj;
        if (figura2.area == this.area)
        {
            return true;
        }
        return false;
    }
    public override FiguraGeometrica Clone()
    {
        return new Rettangolo(baseFigura, altezza);
    }
    public override string ToString()
    {
        return "Figura: Rettangolo \n Lati: " + baseFigura + "," + altezza + "\n Perimetro: " + perimetro + "\n Area: " + area;
    }
}
class Quadrato : Rettangolo
{
    public Quadrato(double lato) : base(lato, lato) { }
    public override string ToString()
    {
        return "Figura: Quadrato \n Lato: " + lato + "\n Perimetro: " + perimetro + "\n Area: " + area;
    }
}
class Rombo : Quadrato
{
    double DiagMaggiore;
    double DiagMinore;
    public Rombo(double lato, double DiagMaggiore, double DiagMinore) : base(lato)
    {
        this.DiagMaggiore = DiagMaggiore;
        this.DiagMinore = DiagMinore;
    }
    public override double CalcolaArea()
    {
        area = (DiagMaggiore * DiagMinore) / 2;
        return area;
    }
    public override string ToString()
    {
        return "Figura: Rombo \n Lato: " + lato + "\n Diagonali: " + DiagMaggiore + "," + DiagMinore + "\n Perimetro: " + perimetro + "\n Area: " + area;
    }
}
class Circonferenza : FiguraGeometrica
{
    public Circonferenza(double raggio)
    {
        this.raggio = raggio;
    }
    public override double CalcolaPerimetro()
    {
        perimetro = raggio * 2 * Math.PI;
        return perimetro;
    }
    public override double CalcolaArea()
    {
        area = raggio * raggio * Math.PI;
        return area;
    }
    public override bool Equals(object obj)
    {
        Circonferenza figura = (Circonferenza)obj;
        if (figura.area == this.area)
        {
            return true;
        }
        return false;
    }
    public override FiguraGeometrica Clone()
    {
        return new Circonferenza(raggio);
    }
    public override string ToString()
    {
        return "Figura: Cerchio \n Raggio: " + raggio + "\n Circonferenza: " + perimetro + "\n Area: " + area;
    }


}
class Raccolta
{
    List<FiguraGeometrica> l;
    List<FiguraGeometrica> lista;
    int conta = 0;
    public Raccolta()
    {
        l = new List<FiguraGeometrica>();
        lista = new List<FiguraGeometrica>();
    }

    public int Add(FiguraGeometrica f)
    {
        l.Add(f);
        calcola();
        return conta++;
    }
    public FiguraGeometrica maxArea()
    {
        FiguraGeometrica max = l.First();
        foreach (var figure2 in l)
        {
            if (figure2.CompareTo(max) > 0)
            {
                max = figure2;
            }
        }
        return max;
    }
    public FiguraGeometrica minPerimetro()
    {
        FiguraGeometrica min = l.First();
        foreach (var figure2 in l)
        {
            if (figure2.CompareToPerimetro(min) < 0)
            {
                min = figure2;
            }
        }
        return min;
    }
    public void ordina()
    {
        l.Sort();
    }
    public string stampa()
    {
        string s = "";
        foreach (var figure2 in l)
        {
            s += figure2.ToString() + "\n----------------\n";
        }
        return s;
    }
    public void calcola()
    {
        foreach (var figure2 in l)
        {
            figure2.CalcolaPerimetro();
            figure2.CalcolaArea();
        }
    }
    public void rimuoviUltima()
    {
        l.RemoveAt(conta - 1);
        conta--;
    }
    public void rimuoviIndice(int indice)
    {
        if (indice < conta)
        {
            l.RemoveAt(indice);
        }
        else
        {
            Console.WriteLine("Indice fuori dalla lista");
        }
        conta--;
    }
    public string ricerca()
    {
        Predicate<FiguraGeometrica> p = x => x.CalcolaArea() > 10;
        string s = "";
        foreach (var figure2 in l)
        {
            if (p.Invoke(figure2))
            {
                s += figure2.ToString() + "\n----------------\n";
            }
        }
        return s;
    }
    public List<FiguraGeometrica> creaLista()
    {
        Type t = l.First().GetType();
        int contal = 0;
        int contaLista = 0;
        foreach (FiguraGeometrica item in lista)
        {
            while(t == item.GetType())
            {
                l.Insert(contal, item);
                lista.Insert(contaLista, maxArea());
            }
            if(t != item.GetType())
            {
                t = item.GetType();
                contal = 0;
            }
        }
        return lista;
    }
    public override string ToString()
    {
        string s = "";
        foreach (FiguraGeometrica item in lista)
        {
            s += item.ToString();
        }
        return s;
    }
}

