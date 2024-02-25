

public class Equipment : Item
{
    public int stateValue;
    public int skillValue;

    private void Start()
    {

    }

    public override void Init(ScriptableObjItem inputData)
    {
        name = inputData.Item.name;
        index = inputData.Item.index;
        img = inputData.Item.img;
        level = inputData.Item.level;
        price = inputData.Item.price;
        infomation = inputData.Item.infomation;
        stateValue = inputData.Item.stateValue;
        skillValue = inputData.Item.skillValue;
    }

    public override void Init(Item inputItem)
    {
        Equipment item = (Equipment)inputItem;
        index = inputItem.index;
        E_type = item.E_type;
        name = item.name;
        img = item.img;
        level = item.level;
        price = item.price;
        infomation = item.infomation;

        if(item.E_type == Types.Shoose)
            stateValue = item.stateValue + ((int)GameManager.Speed + item.stateValue) * item.skillValue;
        else
            stateValue = item.stateValue + (GameManager.Hp + item.stateValue) * item.skillValue;
    }

    public override void Use()
    {
        if (!isUse)
        {
            GameManager.TakeState(this);
            isUse = true;
        }
    }

    public override void Release()
    {
        if (isUse)
        {
            GameManager.TakeAwayState(this);
            isUse = false;
        }
    }
}
