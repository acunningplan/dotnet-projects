import React from "react";
import FunFact from "../../../FunFact/FunFact";
import { ListGroupItem } from "reactstrap";
import { TwitterShareButton, TwitterIcon } from "react-share";

export const FunFactItem = (props: { funFact: FunFact }) => {
  return (
    <>
      <p>{props.funFact.description}</p>
      <TwitterShareButton url="www.google.com">
        <TwitterIcon></TwitterIcon>
      </TwitterShareButton>
    </>
  );
};
