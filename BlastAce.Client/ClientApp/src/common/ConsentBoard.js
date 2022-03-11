import React, { useEffect, useState } from 'react'

const userId = 'JohnDoe'

const Flows = ({onChangeFlow}) => {
  const [flows, setFlows] = useState()

  useEffect(() => {
    fetch('https://localhost:7042/service/v1/flow')
      .then(x => x.json())
      .then(flows => {
        setFlows(flows);
        if (onChangeFlow) {
          onChangeFlow(flows[0])
        }
      })
  }, [])

  return (
    <div>
      <select className='btn' onChange={e => {
        onChangeFlow(flows.find(f => f.name === e.target.value))
      }}>
        {flows?.map(flow => (
          <option>
            {flow.name}
          </option>
        ))}
      </select>
    </div>
  )
}


const PolicyUnsigned = ({appId, flowId, userId}) => {
  const [policies, setPolicies] = useState([]);

  useEffect(() => {
    fetch(`https://localhost:7042/api/v1/decisions3/${appId}/${flowId}/${userId}`)
      .then(x => x.json())
      .then(policies => {
        setPolicies(policies);

        //if (onChangeFlow) {
          //onChangeFlow(decisions[0])
        //}
      })
  }, [appId, flowId, userId])

  return (
    <div className='policy-list'>
      <ul>
        {policies?.map(p => (
          <li onClick={() => {
            if (window.confirm('Should sign document?')) {
              console.log('start signing')

              fetch('https://localhost:7042/api/v1/consent', {
                method: 'POST', // *GET, POST, PUT, DELETE, etc.
                mode: 'cors', // no-cors, *cors, same-origin
                headers: {
                  'Content-Type': 'application/json'
                  // 'Content-Type': 'application/x-www-form-urlencoded',
                },
                body: JSON.stringify({
                  userId: userId,
                  flowId: flowId,
                  appId: appId,
                  policyId: p.id
                })
              })
                .then(x => x.json())
                .then(data => {
                  console.log(data)
                })
            }
          }}>
            {p.policy.name}
          </li>
        ))}
      </ul>
    </div>
  )
}

const PolicySigned = ({appId, flowId, userId}) => {
  const [policies, setPolicies] = useState([]);

  useEffect(() => {
    fetch(`https://localhost:7042/api/v1/decisions2/${appId}/${flowId}/${userId}`)
      .then(x => x.json())
      .then(policies => {
        setPolicies(policies);

        //if (onChangeFlow) {
          //onChangeFlow(decisions[0])
        //}
      })
  }, [appId, flowId, userId])
console.log(policies)
  return (
    <div className='policy-list'>
      <ul>
        {policies?.map(p => (
          <li>
            {p.policy.name}
          </li>
        ))}
      </ul>
    </div>
  )
}


const ConsentBoard = ({appId}) => {

  const [flow, setFlow] = useState();

  if (!flow)
    return (
      <div>
        <h2>loading...</h2>
        <Flows onChangeFlow={flow => setFlow(flow)} />
      </div>
    )

  return (
    <div>
      <h1>Application: {appId}</h1>
      <div className='flow-control'>
        <h1>Flow: </h1>
        <Flows onChangeFlow={flow => setFlow(flow)} />
      </div>
      <h2>Policies</h2>
      <div className="policies-board">
        <div>
          <h5>Unsigned</h5>
          <PolicyUnsigned appId={appId} userId={'QQQQ'} flowId={flow?.name} />
        </div>
        <div>
          <h5>Signed</h5>
          <PolicySigned appId={appId} userId={'QQQQ'} flowId={flow?.name} />
        </div>
      </div>
    </div>
  )
}
  
export { ConsentBoard };
