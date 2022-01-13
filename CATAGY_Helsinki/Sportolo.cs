namespace CATAGY_Helsinki
{
    class Sportolo
    {
        public int ElertHelyezes { get; set; }
        public int SportoloSzama { get; set; }
        public string SportagNeve { get; set; }
        public string VersenyszamNeve { get; set; }

        public Sportolo(string sor)
        {
            var buffer = sor.Split(' ');
            ElertHelyezes = int.Parse(buffer[0]);
            SportoloSzama = int.Parse(buffer[1]);
            SportagNeve = buffer[2];
            VersenyszamNeve = buffer[3];
        }
    }
}
