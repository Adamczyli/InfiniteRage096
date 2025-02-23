using Exiled.API.Features;
using Exiled.CreditTags;
using Exiled.Events.EventArgs.Scp096; 
using Scp096 = Exiled.Events.Handlers.Scp096;

namespace InfinityRage
{
    public class Plugin : Plugin<Config>
    {
        public override string Name => "Infinity rage096";
        public override string Author => ".Adamczyli <3";
        public override string Prefix => "infinityrage";

        public override void OnEnabled()
        {
            base.OnEnabled();

            Scp096.AddingTarget += OnAddingTarget;
            Scp096.CalmingDown += OnRagingEnded; 
        }

        public override void OnDisabled()
        {
            base.OnDisabled();

            Scp096.AddingTarget -= OnAddingTarget;
            Scp096.CalmingDown -= OnRagingEnded;
        }

        private void OnAddingTarget(AddingTargetEventArgs ev)
        {
          
        }

        private void OnRagingEnded(CalmingDownEventArgs ev)
        {
            if (ev.Scp096.Targets.Count > 0)
            {

                ev.IsAllowed = false;
                Log.Debug($"Rage trwa dalej, ponieważ pozostało <color=#FF0101>{ev.Scp096.Targets.Count}</color> targetów do zabicia!");
                ev.Player.ShowHint($"Rage trwa dalej, ponieważ pozostało <color=#FF0101>{ev.Scp096.Targets.Count}</color> targetów.", 1);
            }
            if (ev.Scp096.Targets.Count < 0)
            {
                ev.IsAllowed = true;
                Log.Debug($"⚠️Rage się zakończył, ponieważ nie masz żadnych targetów.⚠️");
            }
        }
    }
}
