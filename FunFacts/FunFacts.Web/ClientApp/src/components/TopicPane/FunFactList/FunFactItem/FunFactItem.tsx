import React, { useState } from "react";
import FunFact from "../../../FunFact/FunFact";
import {
  Dropdown,
  DropdownItem,
  DropdownMenu,
  DropdownToggle,
} from "reactstrap";
import {
  TwitterShareButton,
  TwitterIcon,
  EmailShareButton,
  EmailIcon,
} from "react-share";
import "./FunFactItem.css";
import { environment } from "../../../../environment";

export const FunFactItem = (props: { funFact: FunFact }) => {
  const [dropdownOpen, setDropdownOpen] = useState(false);
  const shareButtonSize = 30;
  const shareButtonProps = {
    title: props.funFact.description,
    windowHeight: 30,
    url: environment.shareUrl,
  };
  return (
    <>
      <p>{props.funFact.description}</p>

      <Dropdown
        isOpen={dropdownOpen}
        toggle={() => setDropdownOpen((isOpen) => !isOpen)}
      >
        <DropdownToggle caret></DropdownToggle>
        <DropdownMenu>
          <DropdownItem header>Share</DropdownItem>
          <DropdownItem text>
            <TwitterShareButton {...shareButtonProps}>
              <TwitterIcon size={shareButtonSize}></TwitterIcon>
            </TwitterShareButton>
            <EmailShareButton {...shareButtonProps}>
              <EmailIcon size={shareButtonSize}></EmailIcon>
            </EmailShareButton>
          </DropdownItem>
        </DropdownMenu>
      </Dropdown>
    </>
  );
};
