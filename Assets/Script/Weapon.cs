
public class Weapon : Item
{ 
    public int stateValue;
    public int skillValue;
    public override void Init(ScriptableObjItem inputData)
    {
        index = inputData.Item.index;
        isUse = inputData.Item.isUsed;
        name = inputData.Item.name;
        img = inputData.Item.img;
        level = inputData.Item.level;
        price = inputData.Item.price;
        infomation = inputData.Item.infomation;
        stateValue = inputData.Item.stateValue;
        skillValue = inputData.Item.skillValue;
    }

    public override void Init(Item inputItem)
    {
        Weapon item = (Weapon)inputItem;
        isUse = inputItem.isUse;
        E_type = item.E_type;
        index = item.index;
        name = item.name;
        img = item.img;
        level = item.level;
        price = item.price;
        infomation = item.infomation;

        stateValue = item.stateValue + (GameManager.Attack + item.stateValue) * item.skillValue;
    }

    public override void Release()
    {
        if (isUse)
        {
            GameManager.TakeAwayState(this);
            isUse = false;
        }
    }

    public override void Use()
    {
        if (!isUse)
        {
            GameManager.TakeState(this);
            isUse = true;
        }
    }
}
