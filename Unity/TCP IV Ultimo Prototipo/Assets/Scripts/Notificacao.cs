public abstract class Notificacao
{
    public static class Fase
    {
        public const string Carregando = "Fase_Carregando";
        public const string Inicio = "Fase_Inicio";
        public const string CriarToupeiras = "Fase_Criar_Toupeiras";
        public const string CriarArmadilhas = "Fase_Criar_Armadilhas";
        public const string AumentarDificuldade = "Fase_Aumentar_Dificuldade";
        public const string Parar = "Fase_Parar";
        public const string Voltar = "Fase_Voltar";
        public const string Fim = "Fase_Fim";
    }
 
    public static class Toupeira
    {
        public const string Surgindo = "Toupeira_Surgindo";
        public const string Idle = "Toupeira_Idle";
        public const string FoiAcertada = "Toupeira_Foi_Acertada";
        public const string Desceu = "Toupeira_Desceu";
        public const string MatarUma = "Toupeira_Matar_Uma";
        public const string MatarTodas = "Toupeira_Matar_Todas";
    }

    public static class Armadilha
    {
        public const string Surgindo = "Armadilha_Surgindo";
        public const string Idle = "Armadilha_Idle";
        public const string Desceu = "Armadilha_Desceu";
        public const string FoiAcertada = "Armadilha_Foi_Acertada";
    }

    public static class Jogador
    {
        public const string PerdeuVida = "Jogador_Perdeu_Vida";
        public const string GanhouPontos = "Jogador_Ganhou_Pontos";
        public const string UsouPowerUp = "Jogador_Usou_PowerUp";
        public const string MatarUmaToupeiraAleatoria = "Jogador_Matar_Uma_Toupeira_Aleatoria";
        public const string MatarTodasToupeiras = "Jogador_Matar_Todas_Toupeiras";
        public const string AcabouPowerUp3 = "Jogador_Acabou_Power_Up_3";
       // public const string PararTempo = "Jogador_Parar_Tempo";
    }

    public static class PowerUp
    {
        public const string Inicio = "PowerUp_Inicio";
    }
    
    public static class Atualizar
    {
        public const string AtualizarUI = "Atualizar_UI";
    }
}
