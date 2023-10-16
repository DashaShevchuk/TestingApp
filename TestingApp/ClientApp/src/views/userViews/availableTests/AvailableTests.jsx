import React, { Component } from "react";
import * as getListActions from "./reducer";
import { connect } from "react-redux";
import get from "lodash.get";
import { Link } from "react-router-dom";
import { Card, Button } from "antd";

class AvailableTests extends Component {
  componentDidMount() {
    this.props.getTests();
  }
  render() {
    const { data } = this.props;

    const cards =
      data &&
      data.map((element) => (
        <Card
          hoverable
          title={element.Name}
          bordered={false}
          key={element.id}
          style={{
            width: 400,
          }}
        >
          <p>{element.Description}</p>
          <Link to={`/user/available/${element.Id}`}>
          <Button type="primary" style={{ width: "100%" }}>
            Start the test
          </Button>
        </Link>
        </Card>
      ));

    return (
      <div
        style={{
          display: "flex",
          justifyContent: "flex-start",
          alignItems: "flex-start",
          height: "100vh",
          width: "100%",
          padding: "3%",
        }}
      >
        {cards}
      </div>
    );
  }
}

const mapStateToProps = (state) => {
  return {
    data: get(state, "availableTests.list.data"),
  };
};

const mapDispatchToProps = (dispatch) => {
  return {
    getTests: () => {
      dispatch(getListActions.getTests());
    }
  };
};

export default connect(mapStateToProps, mapDispatchToProps)(AvailableTests);
