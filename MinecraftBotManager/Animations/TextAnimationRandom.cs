using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media.Animation;

namespace MinecraftBotManager.Animations
{
    public class TextAnimationRandom : AnimationTimeline
    {
        public override Type TargetPropertyType => typeof(string);

        protected override Freezable CreateInstanceCore()
        {
            return new TextAnimationRandom();
            
        }

    }
}
