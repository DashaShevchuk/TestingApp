import React, { Component } from "react";
import * as getListActions from "./reducer";
import { connect } from "react-redux";
import get from "lodash.get";
import { Radio, Checkbox, Card,Carousel  } from 'antd';
import { Link } from "react-router-dom";

class Test extends Component {

  componentDidMount() {
    const testId = this.props.match.params.testId;
     console.log('test', testId)
    this.props.getTest({ testId: testId });
  }

  render() {
    const { data } = this.props;
    console.log("data", data);
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
       <div>
        {data&&data ? (
          data&&data.map((test) => (
            <Card key={test.Id} title={test.TestName} style={{ margin: '10px' }}>
              <p>{test.TestDescription}</p>
              {test.Questions.map((question) => (
                <div key={question.Id}>
                  <p>{question.QuestionText}</p>
                  {question.Answers.length === 1 ? (
                    <Radio.Group>
                      {question.Answers.map((answer) => (
                        <Radio key={answer.Id} value={answer.Id}>
                          {answer.Text}
                        </Radio>
                      ))}
                    </Radio.Group>
                  ) : (
                    <Checkbox.Group>
                      {question.Answers.map((answer) => (
                        <Checkbox key={answer.Id} value={answer.Id}>
                          {answer.Text}
                        </Checkbox>
                      ))}
                    </Checkbox.Group>
                  )}
                </div>
              ))}
            </Card>
          ))
        ) : (
          <div>Loading data...</div>
        )}
      </div>
      </div>
    );
  }
}

const mapStateToProps = (state) => {
  return {
    data: get(state, "test.list.data"),
    loading: get(state, "test.list.loading"),
    failed: get(state, "test.list.failed"),
    success: get(state, "test.list.success"),
  };
};

const mapDispatchToProps = (dispatch) => {
  return {
    getTest: (filter) => {
      dispatch(getListActions.getTest(filter));
    },
  };
};

export default connect(mapStateToProps, mapDispatchToProps)(Test);

//export default Test;