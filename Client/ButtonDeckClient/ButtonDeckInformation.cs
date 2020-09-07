namespace ButtonDeckClient
{
    struct ButtonDeckInformation
    {
        public ButtonDeckInformation(int toggleButtonCount, int pushButtonRows, int pushButtonCols)
        {
            ToggleButtonCount = toggleButtonCount;
            PushButtonRows = pushButtonRows;
            PushButtonCols = pushButtonCols;
        }

        public int ToggleButtonCount { get; }
        public int PushButtonRows { get; }
        public int PushButtonCols { get; }

        public static readonly ButtonDeckInformation Default = new ButtonDeckInformation(8, 5, 5);
    }
}
