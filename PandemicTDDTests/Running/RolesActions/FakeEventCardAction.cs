using PandemicTDD.Actions;

namespace PandemicTDDTests.Materiel
{
    public class FakeEventCardAction : ActionBase
        {
            public override bool ConsumeOneAction => true;

            public bool Played { get; set; } 

            public bool Tried { get; set; } 

            public override void Execute()
            {
                Played = true;
            }

            public override void Try()
            {
                Tried = true;
            }
        }   
}