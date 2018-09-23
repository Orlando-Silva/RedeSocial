﻿namespace Helpers.Interfaces
{
    public interface IValidadorDeSessao<T> where T : class
    {
        bool ValidarSessao(T entidade);
    }
}