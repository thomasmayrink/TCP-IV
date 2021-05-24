public abstract class Notificacao
{
    public static class Fase
    {
        public const string Inicio = "Fase_Inicio";
        public const string CriarToupeiras = "Fase_Criar_Toupeiras";
        public const string CriarArmadilhas = "Fase_Criar_Armadilhas";
        public const string Fim = "Fase_Fim";
    }
 
    public static class Toupeira
    {
        public const string Surgindo = "Toupeira_Surgindo";
        public const string Idle = "Toupeira_Idle";
        public const string Descendo = "Toupeira_Descendo";
        public const string FoiAcertada = "Toupeira_Foi_Acertada";
        public const string Destruir = "Toupeira_Destruir";
    }
}
