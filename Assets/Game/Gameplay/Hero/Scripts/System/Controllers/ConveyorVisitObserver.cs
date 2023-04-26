using Game.Gameplay.Player;
using GameSystem;

namespace Game.Gameplay.Hero
{
    public sealed class ConveyorVisitObserver : TriggerObserver<ConveyorTrigger>
    {
        private ConveyorVisitor conveyorVisitor;

        [GameInject]
        public void Construct(ConveyorVisitor conveyorVisitor)
        {
            this.conveyorVisitor = conveyorVisitor;
        }

        protected override void OnHeroEntered(ConveyorTrigger target)
        {
            var zoneType = target.Zone;
            if (zoneType == ConveyorTrigger.ZoneType.LOAD)
            {
                this.EnterLoadZone(target);
            }

            if (zoneType == ConveyorTrigger.ZoneType.UNLOAD)
            {
                this.EnterUnloadZone(target);
            }
        }

        protected override void OnHeroExited(ConveyorTrigger target)
        {
            var zoneType = target.Zone;
            if (zoneType == ConveyorTrigger.ZoneType.LOAD)
            {
                this.conveyorVisitor.InputZone.Exit();
            }

            if (zoneType == ConveyorTrigger.ZoneType.UNLOAD)
            {
                this.conveyorVisitor.OutputZone.Exit();
            }
        }

        private void EnterLoadZone(ConveyorTrigger trigger)
        {
            var inputZone = this.conveyorVisitor.InputZone;
            if (inputZone.IsEntered)
            {
                inputZone.Exit();
            }
            
            inputZone.Enter(trigger.Conveyor);
        }

        private void EnterUnloadZone(ConveyorTrigger trigger)
        {
            var outputZone = this.conveyorVisitor.OutputZone;
            if (outputZone.IsEntered)
            {
                outputZone.Exit();
            }
            
            outputZone.Enter(trigger.Conveyor);
        }
    }
}