namespace PrototypeUI_3.Model
{
    public class OperateMessage<T>
    {
        public CellOperateType OperateType { get; set; }

        public T Data { get; set; }
    }
}
