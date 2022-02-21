namespace DeskAssistant.Models.StickyNote
{
    internal class NotePosition
    {
        public int Id { get; set; }
        private double Xpos { get; set; }
        private double Ypos { get; set; }




        // set position
        public void fpSetXPos(double Xp)
        {
            Xpos = Xp;
        }

        public void fpSetYPos(double Yp)
        {
            Ypos = Yp;
        }


        // get position
        public double fpGetXPos()
        {
            return (Xpos);
        }

        public double fpGetYPos()
        {
            return (Ypos);
        }





    }
}
