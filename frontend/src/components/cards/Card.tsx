import { PropsWithChildren } from "react";

interface Props extends PropsWithChildren {
  flex: string;
}

const Card = ({ flex, children }: Props) => {
  return (
    <div
      style={{
        backgroundColor: "#ffffff",
        padding: "32px",
        borderRadius: "8px",
        boxShadow: "2px 2px 2px #dbdbdb",
        flex: flex,
      }}
    >
      {children}
    </div>
  );
};

export default Card;
