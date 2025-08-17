import { useQuery } from "@tanstack/react-query";

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
