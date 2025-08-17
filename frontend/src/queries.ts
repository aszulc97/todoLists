import { useMutation, useQuery, useQueryClient } from "@tanstack/react-query";
import { ListItemStatus, UpdateStatusRequest } from "./types";

export const queryKeys = {
  users: ["users"],
  lists: (userId: string) => ["lists", userId],
  listById: (listId: string) => ["listById", listId],
};

export const useUsers = () =>
  useQuery({
    queryKey: queryKeys.users,
    queryFn: () => fetch("/api/users").then((res) => res.json()),
  });

export const useListsForUser = (userId: string) =>
  useQuery({
    queryKey: queryKeys.lists(userId),
    queryFn: () => fetch(`/api/lists/user/${userId}`).then((res) => res.json()),
    enabled: !!userId,
  });

export const useListById = (listId: string) =>
  useQuery({
    queryKey: queryKeys.listById(listId),
    queryFn: () => fetch(`/api/lists/${listId}`).then((res) => res.json()),
    enabled: !!listId,
  });

export const useUpdateItemStatus = (listId: string, listItemId: string) => {
  const queryClient = useQueryClient();
  return useMutation({
    mutationFn: (status: ListItemStatus) =>
      fetch(`/api/list-items/${listItemId}/status`, {
        method: "PUT",
        body: JSON.stringify(status),
        headers: {
          "Content-Type": "application/json",
        },
      }).then((res) => res.json()),
    onSettled: () => {
      queryClient.invalidateQueries({ queryKey: queryKeys.listById(listId) });
    },
  });
};
