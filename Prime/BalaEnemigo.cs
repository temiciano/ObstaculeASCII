namespace Prime
{
    class BalaEnemigo : Bala
    {
        public BalaEnemigo(int posX, int posY, char simboloBalaEnemigo)
            : base(posX, posY, simboloBalaEnemigo)
        {
        }

        public override void Mover()
        {
            y = Math.Max(0, y + 1);
        }
    }
}