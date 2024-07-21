namespace Gestran.VehicleControl.Domain.Exceptions
{
    [Serializable]
    public class MyUniqueConstraintException : Exception
    {
        public MyUniqueConstraintException()
        {

        }

        public MyUniqueConstraintException(string message)
        : base(message) { }

        public MyUniqueConstraintException(string message, Exception inner)
        : base(message, inner) { }
    }
}
