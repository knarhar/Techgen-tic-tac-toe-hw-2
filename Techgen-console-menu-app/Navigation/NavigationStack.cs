using Techgen_console_menu_app.Contracts;

namespace Techgen_console_menu_app.Navigation
{
    internal class NavigationStack
    {
        private IScreen[] _items;
        private int _count;

        public int Count => _count;

        public NavigationStack(int capacity = 2)
        {
            _items = new IScreen[capacity];
            _count = 0;
        }

        public void Push(IScreen item)
        {
            if (_count == _items.Length)
            {
                Resize();
            }

            _items[_count] = item;
            _count++;
        }

        public IScreen Peek()
        {
            if (_count == 0)
            {
                throw new InvalidOperationException("Stack is empty");
            }

            return _items[_count - 1];
        }

        public IScreen Pop()
        {
            if (_count != 0)
            {
                _count--;
                return _items[_count];
            }

            throw new InvalidOperationException("Stack is empty.");
        }

        private void Resize()
        {
            IScreen[] newItems = new IScreen[_items.Length * 2];
            for (int i = 0; i < _items.Length; i++)
            {
                newItems[i] = _items[i];
            }

            _items = newItems;
        }

    }
}
