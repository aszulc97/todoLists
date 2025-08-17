import { useEffect, useState } from "react";
import Card from "./cards/Card";
import { List, User } from "../types";
import { useUsers } from "../queries";
import ListsCard from "./cards/ListsCard";
import ListItemsCard from "./cards/ListItemsCard";
import UsersCard from "./cards/UsersCard";

const PageContent = () => {
  const [selectedUser, setSelectedUser] = useState<User | null>(null);
  const [selectedList, setSelectedList] = useState<List | null>(null);

  return (
    <div style={{ padding: "32px", backgroundColor: "#e3f1fc" }}>
      <div
        style={{
          display: "flex",
          flexDirection: "row",
          gap: "16px",
        }}
      >
        <UsersCard
          selectedUser={selectedUser}
          setSelectedUser={setSelectedUser}
        />
        {selectedUser && (
          <ListsCard
            selectedUser={selectedUser}
            selectedList={selectedList}
            setSelectedList={setSelectedList}
          />
        )}
        {selectedList && <ListItemsCard selectedList={selectedList} />}
      </div>
    </div>
  );
};

export default PageContent;
