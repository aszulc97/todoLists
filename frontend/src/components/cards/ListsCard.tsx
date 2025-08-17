import { useEffect } from "react";
import { useListsForUser } from "../../queries";
import { List, User } from "../../types";
import Card from "./Card";

interface Props {
  selectedUser: User;
  selectedList: List | null;
  setSelectedList: (list: List | null) => void;
}

const ListsCard = ({ selectedUser, selectedList, setSelectedList }: Props) => {
  const { data } = useListsForUser(selectedUser.id);
  useEffect(() => {
    if (data) setSelectedList(data[0]);
  }, [data]);
  return (
    <Card flex={"0.2"}>
      <h4 style={{ marginTop: 0 }}>{`${selectedUser?.name}'s lists`}</h4>
      {data &&
        data.map((list: List) => (
          <label key={list.id}>
            <input
              type={"radio"}
              name={"list"}
              checked={selectedList === list}
              onChange={() => setSelectedList(list)}
            />
            {list.name}
          </label>
        ))}
    </Card>
  );
};

export default ListsCard;
