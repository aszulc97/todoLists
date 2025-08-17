import { useListById } from "../../queries";
import { List, ListItem, User } from "../../types";
import Card from "./Card";

interface Props {
  selectedList: List;
}

const ListItemsCard = ({ selectedList }: Props) => {
  const { data } = useListById(selectedList.id);
  console.log(data);
  return (
    <Card flex={"0.6"}>
      <h4 style={{ marginTop: 0 }}>{`Tasks in ${selectedList?.name}`}</h4>
      {data &&
        data.items.map((item: ListItem) => (
          <label key={item.id}>
            <input
              type={"checkbox"}
              name={"list"}
              checked={item.status}
              //   onChange={() => setSelectedList(list)}
            />
            {item.title}
          </label>
        ))}
    </Card>
  );
};

export default ListItemsCard;
