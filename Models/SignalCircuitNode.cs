namespace AdventOfCode2015.Models
{
    public abstract class SignalCircuitNode
    {
        private ushort _signal;
        private bool _signalSet;
        public string Name { get; }

        protected SignalCircuitNode(string name)
        {
            Name = name;
            _signal = 0;
            _signalSet = false;
        }

        public ushort ProvideSignal()
        {
            if(_signalSet)
                return _signal;
            _signalSet = true;
            return _signal = ProvideSignalushorternal();
        }

        public void ResetSignal() => _signalSet = false;

        public void SetSignal(ushort signal)
        {
            _signal = signal;
            _signalSet = true;
        }

        protected abstract ushort ProvideSignalushorternal();
    }

    public class SignalCircuitBasedNode : SignalCircuitNode
    {
        private SignalCircuitNode _signalProvider;

        public SignalCircuitBasedNode(string name, SignalCircuitNode signalProvider) : base(name)
        {
            _signalProvider = signalProvider;
        }

        protected override ushort ProvideSignalushorternal() => _signalProvider.ProvideSignal();
    }

    public class SignalCircuitLeafNode : SignalCircuitNode
    {
        private readonly ushort _value;

        public SignalCircuitLeafNode(string name, ushort value) : base(name)
        {
            _value = value;
        }
        
        protected override ushort ProvideSignalushorternal() => _value;
    }

    public class SignalCircuitNotNode : SignalCircuitNode
    {
        private readonly SignalCircuitNode _signalProvider;

        public SignalCircuitNotNode(string name, SignalCircuitNode signalProvider) : base(name)
        {
            _signalProvider = signalProvider;
        }

        protected override ushort ProvideSignalushorternal() => (ushort)(~_signalProvider.ProvideSignal());
    }

    public abstract class SignalCircuitBinaryOperationNode : SignalCircuitNode
    {
        private readonly SignalCircuitNode _leftSignalProvider;
        private readonly SignalCircuitNode _rightSignalProvider;
        private readonly Func<ushort,ushort,ushort> _combineFunction;

        protected SignalCircuitBinaryOperationNode(string name, Func<ushort, ushort, ushort> combineFunction, SignalCircuitNode leftSignalProvider, SignalCircuitNode rightSignalProvider)
            : base(name)
        {
            _combineFunction = combineFunction;
            _leftSignalProvider = leftSignalProvider;
            _rightSignalProvider = rightSignalProvider;
        }

        protected override ushort ProvideSignalushorternal()
        {
            return _combineFunction(_leftSignalProvider.ProvideSignal(), _rightSignalProvider.ProvideSignal());
        }
    }

    public class SignalCircuitOrNode : SignalCircuitBinaryOperationNode
    {
        public SignalCircuitOrNode(string name, SignalCircuitNode leftSignalProvider, SignalCircuitNode rightSignalProvider) 
            : base(name, (a, b) => (ushort)(a | b), leftSignalProvider, rightSignalProvider)
        {
        }
    }

    public class SignalCircuitAndNode : SignalCircuitBinaryOperationNode
    {
        public SignalCircuitAndNode(string name, SignalCircuitNode leftSignalProvider, SignalCircuitNode rightSignalProvider) 
            : base(name, (a, b) => (ushort)(a & b), leftSignalProvider, rightSignalProvider)
        {
        }
    }

    public class SignalCircuitLeftShiftNode : SignalCircuitBinaryOperationNode
    {
        public SignalCircuitLeftShiftNode(string name, SignalCircuitNode leftSignalProvider, SignalCircuitNode rightSignalProvider) 
            : base(name, (a, b) => (ushort)(a << b), leftSignalProvider, rightSignalProvider)
        {
        }
    }

    public class SignalCircuitRightShiftNode : SignalCircuitBinaryOperationNode
    {
        public SignalCircuitRightShiftNode(string name, SignalCircuitNode leftSignalProvider, SignalCircuitNode rightSignalProvider) 
            : base(name, (a, b) => (ushort)(a >> b), leftSignalProvider, rightSignalProvider)
        {
        }
    }
}