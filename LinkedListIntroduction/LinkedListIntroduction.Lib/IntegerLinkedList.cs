namespace LinkedListIntroduction.Lib;

public class IntegerLinkedList
{
    IntegerNode _head;
   
    public IntegerLinkedList()
    {
        _head = null;
    }

    public IntegerLinkedList(int v)
    {
        _head = new IntegerNode(v);
    }

    public int Count => _head == null ? 0 : _head.Count;
    public int Sum => _head == null ? 0 : _head.Sum;

    public void Append(int v)
    {
        if (_head == null)
            _head = new IntegerNode(v);
        else
            _head.Append(v);

    }

    public void Prepend(int v)
    {
        _head = new IntegerNode(v, _head);
    }

    public bool Delete(int v)
    {
        if (_head == null)
            return false;
        else
            return _head.Delete(v);
    }

    public void Insert(int v, int pos)
    {
        if (pos > Count-1 || pos < 0) throw new IndexOutOfRangeException();
        if (pos == 0) Prepend(v);
        else _head.Insert(v, pos-1);
    }

    public void Join(IntegerLinkedList ill)
    {
        if (_head == null) _head = ill._head;
        if (ill._head == null) return;
        else _head.Join(ill._head);
    }

    public bool Contains(int v)
    {
        if (_head == null) return false;
        else return _head.Contains(v);
    }

    public void RemoveDuplicates()
    {
        HashSet<int> seen = new HashSet<int>();
        _head.RemoveDuplicates(seen);
    }

    public override string ToString()
    {
        return _head == null ? "{}" : $"{{{_head}}}";
    }
}

public class IntegerNode
{
    int _value;

    public int Value => _value;
    IntegerNode _next;

    internal int Count => _next == null ? 1 : 1 + _next.Count;
            
    internal int Sum => _next == null ? _value : _value + _next.Sum;


    internal IntegerNode(int v)
    {
        _value = v;
        _next = null;
    }

    internal IntegerNode(int v, IntegerNode n)
    {
        _value = v;
        _next = n;
    }

    internal void Append(int v)
    {
        if (_next == null)
            _next = new IntegerNode(v);
        else
            _next.Append(v);
    }

    internal bool Delete(int v)
    {
        if (_next == null)
            return false;
        if (_next._value == v)
        {
            _next = _next._next;
            return true;
        }
        else
        {
            return _next.Delete(v);
        }
    }

    internal void Insert(int v, int pos)
    {
        if (pos == 0) _next = new IntegerNode(v, _next);
        else _next.Insert(v, pos-1);
    }

    internal void Join(IntegerNode node)
    {
        if (_next == null) _next = node;
        else _next.Join(node);
    }

    internal bool Contains(int v)
    {
        if (_next == null) return false;
        if (_next._value == v) return true;
        else return _next.Contains(v);
    }

    internal void RemoveDuplicates(HashSet<int> seen)
    {
        if (_next == null) return;
        if (seen.Contains(_next._value))
        {
            _next = _next._next;
            RemoveDuplicates(seen);
        }
        else
        {
            seen.Add(_next._value);
            _next.RemoveDuplicates(seen);
        }
    }

    public override string ToString()
    {
        return _next == null ? _value.ToString() : $"{_value}, {_next}";
    }

}
