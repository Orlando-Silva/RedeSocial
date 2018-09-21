namespace Services.Estruturas
{
    public class Construtor<T> where T : class, new()
    {
        #region --Atributos--
        protected static T Entidade { get; set; }
        #endregion

        #region --Construtores--
        public Construtor()
        {
            Entidade = new T();
        }

        public Construtor(T _entity)
        {
            Entidade = _entity;
        }
        #endregion

        #region --Operador de Conversão Implicita--
        public static implicit operator T(Construtor<T> _construtor) => Entidade;
        #endregion
    }
}
