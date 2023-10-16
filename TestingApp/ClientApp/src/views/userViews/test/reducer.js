import TestService from "./TestService";
import update from "../../../helpers/update";

export const TEST_STARTED = "TEST_STARTED";
export const TEST_SUCCESS = "TEST_SUCCESS";
export const TEST_FAILED = "TEST_FAILED";

const initialState = {
  list: {
    data: null,
    loading: false,
    success: false,
    failed: false,
  },
};

export const getTest = (model) => {
  return (dispatch) => {
    dispatch(getListActions.started());
    TestService.getTest(model)
      .then(
        (response) => {
          console.log("response", response);
          dispatch(getListActions.success(response));
        },
        (err) => {
          throw err;
        }
      )
      .catch((err) => {
        dispatch(getListActions.failed(err));
      });
  };
};

export const getListActions = {
  started: () => {
    return {
      type: TEST_STARTED,
    };
  },
  success: (data) => {
    return {
      type: TEST_SUCCESS,
      payload: data.data,
    };
  },
  failed: (error) => {
    return {
      type: TEST_FAILED,
      errors: error,
    };
  },
};

export const testReducer = (state = initialState, action) => {
  let newState = state;

  switch (action.type) {
    case TEST_STARTED: {
      newState = update.set(state, "list.loading", true);
      newState = update.set(newState, "list.success", false);
      newState = update.set(newState, "list.failed", false);
      break;
    }
    case TEST_SUCCESS: {
      newState = update.set(state, "list.loading", false);
      newState = update.set(newState, "list.failed", false);
      newState = update.set(newState, "list.success", true);
      newState = update.set(newState, "list.data", action.payload);
      break;
    }
    case TEST_FAILED: {
      newState = update.set(state, "list.loading", false);
      newState = update.set(newState, "list.success", false);
      newState = update.set(newState, "list.failed", true);
      break;
    }
    default: {
      return newState;
    }
  }
  return newState;
};
