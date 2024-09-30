namespace Desafio.WebApp.Shared.Core.Entities;

// Deixei com esse nome por conta da Entity do CSharpFunctionExtensions
public abstract class Entidade<TKey>
{
    public TKey Id { get; set; }

    public override bool Equals(object obj)
    {
        var compareTo = obj as Entidade<TKey>;

        if (ReferenceEquals(this, compareTo))
            return true;

        if (compareTo is null) 
            return false;

        return Id.Equals(compareTo.Id);
    }

    public static bool operator ==(Entidade<TKey> a, Entidade<TKey> b)
    {
        if (a is null && b is null)
            return true;

        if (a is null || b is null)
            return false;

        return a.Equals(b);
    }

    public static bool operator !=(Entidade<TKey> a, Entidade<TKey> b)
    {
        return !(a == b);
    }

    public override int GetHashCode()
    {
        return (GetType().GetHashCode() * 907) + Id.GetHashCode();
    }

    public override string ToString()
    {
        return $"{GetType().Name} [Id={Id}]";
    }
}


