using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Documents;
using System.Windows.Media;
using System.Windows;

namespace JulioCode01.Views
{
    //https://stackoverflow.com/questions/24515852/using-adorner-to-show-stretched-overlay-containing-uielements
    class OverlayAdorner : Adorner {
        private FrameworkElement _content;

        public OverlayAdorner(UIElement adornedElement)
            : base(adornedElement) {
        }

        protected override int VisualChildrenCount {
            get {
                return _content == null ? 0 : 1;
            }
        }

        protected override Visual GetVisualChild(int index) {
            if (index != 0) throw new ArgumentOutOfRangeException();
            return _content;
        }

        public FrameworkElement Content {
            get { return _content; }
            set {
                if (_content != null) {
                    RemoveVisualChild(_content);
                }
                _content = value;
                if (_content != null) {
                    AddVisualChild(_content);
                }
            }
        }

        protected override Size ArrangeOverride(Size finalSize) {
            _content.Arrange(new Rect(new Point(0, 0), finalSize));
            return base.ArrangeOverride(finalSize);
        }
    }
}
