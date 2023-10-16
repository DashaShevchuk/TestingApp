import React, { Component } from "react";
import { connect } from "react-redux";
import * as loginActions from "./reducer";
import get from "lodash.get";
import PropTypes from "prop-types";
import { Typography, Button, Form, Input, message } from "antd";
import { LockOutlined, UserOutlined } from '@ant-design/icons';
const { Title } = Typography;

class LoginPage extends Component {
  state = {
    username: "",
    password: "",
    errorsServer: "",
    isLoading: false,
  };

  componentDidUpdate(prevProps) {
    const { failed } = this.props;

    if (failed && !prevProps.failed) {
      this.setState({ isLoading: false });
      message.error("Неправильний логін або пароль", 3);
    }
  }

  onSubmitForm = () => {
    const { username, password } = this.state;
    console.log("onSubmitForm", this.state);

    this.setState({ isLoading: true });
    const model = {
      username: username,
      password: password,
    };

    this.props.login(model, this.props.history);
  };

  render() {
    const { isLoading } = this.state;

    return (
      <div>
         {/* <div>Loading..</div> */}
        <div
        style={{display:'flex', justifyContent:'center', alignItems:'center', width:'100%', height:'100vh'}}
        >
            <Form
              name="loginForm"
              layout="vertical"
              autoComplete="off"
              onFinish={this.onSubmitForm}
              labelCol={{
                span: 6,
              }}
              wrapperCol={{
                span: 25,
              }}
              initialValues={{
                size: "large",
              }}
            >
             <Form.Item
          name="username"
          rules={[
            {
              required: true,
              message: 'Please input your Username!',
            },
          ]}
        >
          <Input prefix={<UserOutlined className="site-form-item-icon" />} 
          placeholder="Username" 
          onChange={(e) => {
                    this.setState({ username: e.target.value });
                  }}/>
        </Form.Item>
        <Form.Item
          name="password"
          rules={[
            {
              required: true,
              message: 'Please input your Password!',
            },
          ]}
        >
          <Input
            prefix={<LockOutlined className="site-form-item-icon" />}
            type="password"
            placeholder="Password"
            onChange={(e) => {
              this.setState({ password: e.target.value });
            }}
          />
        </Form.Item>
        <Form.Item>
          <Button type="primary" htmlType="submit" className="login-form-button">
            Log in
          </Button>
        </Form.Item>
            </Form>
        </div>
      </div>
    );
  }
}

LoginPage.propTypes =
{
  login: PropTypes.func.isRequired
}

function mapStateToProps(state) {
  return {
    loading: get(state, 'login.post.loading'),
    failed: get(state, 'login.post.failed'),
    success: get(state, 'login.post.success'),
    errors: get(state, 'login.post.errors')
  }
}

const mapDispatchToProps = {
  login: (model, history) => {
    return loginActions.login(model, history);
  }
}


export default connect(mapStateToProps, mapDispatchToProps)(LoginPage);
