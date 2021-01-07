namespace Interfaces
{
    public interface IInitiable<T1>
    {
        void Init(T1 obj1);
    }

    public interface IInitiable<T1, T2>
    {
        void Init(T1 obj1, T2 obj2);
    }

    public interface IInitiable<T1, T2, T3>
    {
        void Init(T1 obj1, T2 obj2, T3 obj3);
    }

    public interface IInitiable<T1, T2, T3, T4>
    {
        void Init(T1 obj1, T2 obj2, T3 obj3, T4 obj4);
    }

    public interface IInitiable<T1, T2, T3, T4, T5>
    {
        void Init(T1 obj1, T2 obj2, T3 obj3, T4 obj4, T5 obj5);
    }

    public interface IInitiable<T1, T2, T3, T4, T5, T6> {
        void Init(T1 obj1,T2 obj2,T3 obj3,T4 obj4,T5 obj5,T6 obj6);
    }
}

