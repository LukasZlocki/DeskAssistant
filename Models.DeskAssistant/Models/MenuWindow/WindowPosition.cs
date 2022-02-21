namespace DeskAssistant.Models.MenuWindow
{
    public class WindowPosition
    {
        private double Xpos = 0;
        private double Ypos = 0;


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
