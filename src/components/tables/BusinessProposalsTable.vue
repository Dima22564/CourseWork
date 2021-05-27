<template>
  <div>
    <q-table
      :data="data"
      :columns="columns"
      row-key="name"
      binary-state-sort
      :loading="loading"
      no-data-label="Нет данных"
    >
      <template v-slot:top>
        <div class="flex justify-between flex-center" style="width: 100%">
          <h6 class="q-ma-none">Коммерческие предложения</h6>
          <q-btn
            v-if="$route.params.partnerId"
            :to="'/new-business-proposal/create?partner=' + $route.params.partnerId"
            size="sm"
            color="primary"
            :icon="icons.mdiPencil"
            label="новое предложение"
          />
          <q-btn
            v-else
            to="/new-business-proposal/"
            size="sm"
            color="primary"
            :icon="icons.mdiPencil"
            label="новое предложение"
          />
        </div>
      </template>
      <template v-slot:body="props">
        <q-tr :props="props">
          <q-td key="number" :props="props">
            {{ props.row.number }}
          </q-td>

          <q-td key="from" :props="props">
            {{ dateFormat(props.row.from) }}
          </q-td>

          <q-td key="company" :props="props">
            {{ props.row.company.name.workName }}
          </q-td>

          <q-td key="validFrom" :props="props">
            {{ dateFormat(props.row.validFrom) }}
          </q-td>

          <q-td key="validTo" :props="props">
            {{ dateFormat(props.row.validTo) }}
          </q-td>

          <q-td key="status" :props="props">
            {{ props.row.status }}
          </q-td>

          <q-td key="actions" :props="props">
            <q-btn-dropdown v-if="props.row.status !== 'NotValid' && props.row.status !== 'Rejected'" class="q-mr-sm" size="sm" color="deep-orange" label="Изменить статус">
              <q-list>
                <q-item clickable v-close-popup @click="changeStatus({ number: props.row.number, status: 'approve' })">
                  <q-item-section>
                    <q-item-label title="Утвердить отпраленное коммерческое предложение.">Утвердить</q-item-label>
                  </q-item-section>
                </q-item>

                <q-item clickable v-close-popup @click="changeStatus({ number: props.row.number, status: 'reject' })">
                  <q-item-section>
                    <q-item-label title="Отклоняет коммерческое предложние, отправленное на утверждение.">Отклонить</q-item-label>
                  </q-item-section>
                </q-item>

                <q-item clickable v-close-popup @click="changeStatus({ number: props.row.number, status: 'invalidate' })">
                  <q-item-section>
                    <q-item-label title="Аннулирует действующее коммерческое предложение.">Аннулировать</q-item-label>
                  </q-item-section>
                </q-item>
              </q-list>
            </q-btn-dropdown>
            <q-btn
              :to="'/new-order/create?businessProposal=' + props.row.number"
              class="q-mr-sm"
              color="primary"
              size="sm"
              label="Создать заказ"
              :loading="loading"
              v-if="props.row.status === 'Approved' || props.row.status === 'Valid'"
            >
              <q-tooltip>
                Создать заказ на основании коммерческого предложения.
              </q-tooltip>
            </q-btn>
            <q-btn class="q-mr-sm" :to="'/marketing/business-proposal/view/' + props.row.businessProposalId" color="secondary" size="sm" label="Просмотр" :loading="loading" />
            <q-btn
              color="purple"
              size="sm"
              :icon="icons.mdiSend"
              :loading="loading"
              v-if="props.row.status === 'NotApproved'"
            >
              <q-tooltip>
                Отправить на утверждение контактному лицу партнера.
              </q-tooltip>
            </q-btn>
          </q-td>
        </q-tr>
      </template>
    </q-table>

  </div>
</template>

<script>
import icons from 'src/mixins/icons'
import moment from 'moment'
export default {
  name: 'BusinessProposalsTable',
  mixins: [icons],
  props: {
    data: {
      type: Array,
      default: () => []
    },
    loading: {
      type: Boolean,
      default: () => false
    }
  },
  methods: {
    dateFormat (date) {
      return moment(date).format('ll')
    },
    async changeStatus (data) {
      try {
        await this.$store.dispatch('businessProposal/changeStatus', data)
      } catch (e) {
      }
    }
  },
  data: () => {
    return {
      createAgreement: false,
      columns: [
        { name: 'number', label: '#', align: 'left', field: 'number' },
        { name: 'from', label: 'От', field: 'from' },
        { name: 'company', label: 'Компания', field: 'company' },
        { name: 'validFrom', label: 'Действут с', field: 'validFrom' },
        { name: 'validTo', label: 'Действует по', field: 'validTo' },
        { name: 'status', label: 'Статус', field: 'status' },
        { name: 'actions', label: 'Действия', field: 'actions' }
      ]
    }
  }
}
</script>
