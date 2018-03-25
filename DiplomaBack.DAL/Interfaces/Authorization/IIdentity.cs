namespace DiplomaBack.DAL.Interfaces.Authorization
{
    public interface IIdentity
    {
        // Тип аутентификации
        string AuthenticationType { get; }
        // атунтифицирован ли пользователь
        bool IsAuthenticated { get; }
        //Имя текущего пользователя 
        string Name { get; }
    }
}
