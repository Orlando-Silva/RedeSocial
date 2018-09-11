namespace Builders
{
    public class Builder<T> where T : class, new()
    {
        #region --Atributos--
        /// <summary>
        ///     Entidade genérica que é construida pelo Builder.
        /// </summary>
        protected static T Entidade { get; set; }
        #endregion

        #region --Construtores--
        /// <summary>
        ///     Inicializa a entidade a ser construida com uma nova instância.
        /// </summary>
        public Builder()
        {
            Entidade = new T();
        }

        /// <summary>
        ///     Inicializa a entidade a ser construida com uma instância existente.
        /// </summary>
        /// <param name="_entity">Instância existente da entidade genérica.</param>
        public Builder(T _entity)
        {
            Entidade = _entity;
        }
        #endregion

        #region --Operador de Conversão Implicita--
        public static implicit operator T(Builder<T> _builder) => Entidade;
        #endregion
    }
}
