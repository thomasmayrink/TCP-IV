public abstract class Notificacao
{
    public static class Fase
    {
        public const string Inicio = "Fase_Inicio";
        public const string CriarToupeiras = "Fase_Criar_Toupeiras";
        public const string CriarArmadilhas = "Fase_Criar_Armadilhas";
        public const string AumentarDificuldade = "Fase_Aumentar_Dificuldade";
        public const string Fim = "Fase_Fim";
    }
 
    public static class Toupeira
    {
        public const string Surgindo = "Toupeira_Surgindo";
        public const string Idle = "Toupeira_Idle";
        public const string FoiAcertada = "Toupeira_Foi_Acertada";
        public const string Desceu = "Toupeira_Desceu";
       // public const string Destruir = "Toupeira_Destruir";
    }

    public static class Armadilha
    {
        public const string Surgindo = "Armadilha_Surgindo";
    }

    public static class Jogador
    {
        public const string Inicio = "Jogador_Inicio";
        public const string PerdeuVida = "Jogador_Perdeu_Vida";
        public const string GanhouPontos = "Jogador_Ganhou_Pontos";
    }

    public static class Atualizar
    {
        public const string AtualizarUI = "Atualizar_UI";
    }
}
