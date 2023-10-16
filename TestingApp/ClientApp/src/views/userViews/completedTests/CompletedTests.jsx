import React, { useState } from "react";
import { connect } from "react-redux";
import get from "lodash.get";

const CompletedTests = () => {

  return (
    <div style={{display:'flex', justifyContent:'center', alignItems:'center', width:'100%', height:'100vh', backgroundColor:"transparent"}}>
  CompletedTests
    </div>
  );
  }

function mapStateToProps(state) {
    return {
        data: get(state, "completedTests.list.data"),
      };
}

const mapDispatchToProps = {
    getTests: (filter) => {
        dispatch(getListActions.getTests(filter));
      },
}

export default connect(mapStateToProps, mapDispatchToProps)(CompletedTests);
