import { useUpdateItemStatus } from "../queries";
import { ListItem, ListItemStatus } from "../types";

interface Props {
  item: ListItem;
}

const Item = ({ item }: Props) => {
  const { mutate: updateStatus } = useUpdateItemStatus(item.listId, item.id);
  const handleUpdateStatus = () => {
    if (item.status === ListItemStatus.Todo) updateStatus(ListItemStatus.Done);
    else updateStatus(ListItemStatus.Todo);
  };
  const isDone = item.status === ListItemStatus.Done;
  return (
    <label style={{ textDecoration: isDone ? "line-through" : "none" }}>
      <input
        type={"checkbox"}
        name={"list"}
        checked={isDone}
        onChange={handleUpdateStatus}
      />
      {item.title}
    </label>
  );
};

export default Item;
