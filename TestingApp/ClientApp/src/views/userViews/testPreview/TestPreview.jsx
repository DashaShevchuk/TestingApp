import React, { Component } from "react";
import * as getListActions from "./reducer";
import { connect } from "react-redux";
import get from "lodash.get";
import { Button, Typography } from "antd";
import { Link } from "react-router-dom";

class TestPreview extends Component {

  componentDidMount() {
    const testId = this.props.match.params.testId;
    this.props.getTestsPreview({ testId: testId });
  }

  render() {
    const { data } = this.props;

    return (
      <div
        style={{
          display: "flex",
          justifyContent: "center",
          alignItems: "center",
          flexDirection: "column",
          width: "100%",
          padding: "3%",
        }}
      >
        <Typography.Title level={1}>Test: {data && data.Name}</Typography.Title>
        <Typography.Title level={5}>
          {data && data.Description}
        </Typography.Title>
        <Typography.Title type="secondary" level={5}>
          {data && data.QuestionsCount} questions
        </Typography.Title>
        <Link
          to={`/user/${data && data.Id}`}
          style={{ width: "20%", display: "flex", justifyContent: "center" }}
        >
          <Button type="primary" ghost>
            Start
          </Button>
        </Link>
      </div>
    );
  }
}

const mapStateToProps = (state) => {
  return {
    data: get(state, "testPreview.list.data"),
    loading: get(state, "testPreview.list.loading"),
    failed: get(state, "testPreview.list.failed"),
    success: get(state, "testPreview.list.success"),
  };
};

const mapDispatchToProps = (dispatch) => {
  return {
    getTestsPreview: (filter) => {
      dispatch(getListActions.getTestsPreview(filter));
    },
  };
};

export default connect(mapStateToProps, mapDispatchToProps)(TestPreview);
