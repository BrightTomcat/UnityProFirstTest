namespace Game.GameEngine
{
    public interface ITimeShiftListener
    {
        void OnTimeShifted(TimeShiftReason reason, float shiftSeconds);
    }
}