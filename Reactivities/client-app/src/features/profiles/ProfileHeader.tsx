import React from "react";
import {
  Segment,
  Item,
  Header,
  Button,
  Grid,
  Statistic,
  Divider,
  Reveal
} from "semantic-ui-react";
import { IProfile } from "../../app/models/profile";
import { observer } from "mobx-react-lite";

interface IProps {
  userData: {
    profile: IProfile;
    isCurrentUser: boolean;
    follow: (username: string) => void;
    unfollow: (username: string) => void;
  };
  loading: boolean;
}

const ProfileHeader: React.FC<IProps> = ({ userData, loading }) => {
  const { profile, follow, unfollow, isCurrentUser } = userData;
  return (
    <Segment>
      <Grid>
        <Grid.Column width={12}>
          <Item.Group>
            <Item>
              <Item.Image
                avatar
                size="small"
                src={profile.image || "/assets/user.png"}
              />
              <Item.Content verticalAlign="middle">
                <Header as="h1">{profile.displayName}</Header>
              </Item.Content>
            </Item>
          </Item.Group>
        </Grid.Column>
        <Grid.Column width={4}>
          <Statistic.Group widths={2}>
            <Statistic label="Followers" value={profile.followersCount} />
            <Statistic label="Following" value={profile.followingCount} />
          </Statistic.Group>
          {!isCurrentUser && (
            <>
              <Divider />
              <Reveal animated="move">
                <Reveal.Content visible style={{ width: "100%" }}>
                  <Button
                    fluid
                    color={profile.following ? "teal" : "grey"}
                    content={profile.following ? "Following" : "Follow"}
                  />
                </Reveal.Content>
                <Reveal.Content hidden>
                  <Button
                    loading={loading}
                    fluid
                    color={profile.following ? "red" : "teal"}
                    content={profile.following ? "Unfollow" : "Follow"}
                    onClick={
                      profile.following
                        ? () => unfollow(profile.username)
                        : () => follow(profile.username)
                    }
                  />
                </Reveal.Content>
              </Reveal>
            </>
          )}
        </Grid.Column>
      </Grid>
    </Segment>
  );
};

export default observer(ProfileHeader);
