import { useListById } from "../../queries";
import { List, ListItem, ListItemStatus, User } from "../../types";
import Item from "../Item";
import Card from "./Card";

interface Props {
  selectedList: List;
}

const ListItemsCard = ({ selectedList }: Props) => {
  const { data } = useListById(selectedList.id);

  return (
    <Card flex={"0.6"}>
      <h4 style={{ marginTop: 0 }}>{`Tasks in ${selectedList?.name}`}</h4>
      {data &&
        data.items.map((item: ListItem) => <Item key={item.id} item={item} />)}
    </Card>
  );
};

export default ListItemsCard;
