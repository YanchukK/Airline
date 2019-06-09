namespace Airline
{
    partial class Airline
    {
        enum Status
        {
            CheckIn = 1, // регистрация идет в данный момент
            GateClosed, // ворота закрыты
            Arrived, // прибыл
            DepartedAt, // вылетел
            Unknown, // неизвестно
            Canceled, // отменен
            ExpectedAt, // ожидается
            Delayed, // рейс задерживается
            InFlight // в полете
        }
    }
}
