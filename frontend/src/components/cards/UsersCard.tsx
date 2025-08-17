import { useEffect } from "react";
import { User } from "../../types";
import { useUsers } from "../../queries";
import Card from "./Card";

interface Props {
  selectedUser: User | null;
  setSelectedUser: (user: User | null) => void;
}

const UsersCard = ({ selectedUser, setSelectedUser }: Props) => {
  const { data } = useUsers();
  useEffect(() => {
    if (data) setSelectedUser(data[0]);
  }, [data]);
  return (
    <Card flex={"0.2"}>
      <div style={{ display: "flex", flexDirection: "column" }}>
        <h4 style={{ marginTop: 0 }}>Select user</h4>
        {data &&
          data.map((user: User) => (
            <label key={user.id}>
              <input
                type={"radio"}
                name={"user"}
                checked={selectedUser === user}
                onChange={() => setSelectedUser(user)}
              />
              {user.name}
            </label>
          ))}
      </div>
    </Card>
  );
};

export default UsersCard;
